// Copyright © 2025 Steven Peterson
// All rights reserved.  
// 
// No part of this code may be copied, modified, distributed, or used  
// without explicit written permission from the author.
// 
// For licensing inquiries or collaboration opportunities:
// 
// GitHub: https://github.com/peterss7  
// LinkedIn: https://www.linkedin.com/in/steven-peterson7405926/

import { Injectable } from '@angular/core';
import { ModalData } from '../models/modal-data.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  private modalDataSubject = new BehaviorSubject<ModalData>(new ModalData());
  public modalData$ = this.modalDataSubject.asObservable();

  private _modalData: ModalData = new ModalData();

  get modalData(): ModalData{
    return this._modalData;
  }

  setModalData(type: string): void {
    const data: ModalData = this.modalDataSubject.value;
    data.modalType = type;
    data.isModalOpen = !data.isModalOpen;
    this.modalDataSubject.next(data);
    this._modalData = data;
    console.log(`modalData: ${JSON.stringify(data)}`);
  }
}
