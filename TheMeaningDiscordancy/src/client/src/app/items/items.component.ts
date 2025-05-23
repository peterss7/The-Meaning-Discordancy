import { Component, OnDestroy, OnInit } from '@angular/core';
import { ModalService } from '../shared/services/modal.service';
import { ModalData } from '../shared/models/modal-data.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'discord-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.scss']
})
export class ItemsComponent implements OnInit, OnDestroy{

  private modalDataSub: Subscription | null = null;
  public modalData: ModalData = new ModalData();

  constructor(public modalService: ModalService,
  ) { }

  ngOnInit(){
    this.modalDataSub = this.modalService.modalData$.subscribe(data => {
      if (data){
          console.log(`Found modal config: ${JSON.stringify(data)}`);
          this.modalData = data;
      }
      else{
        console.error("No modal data found...");
      }
    });
  }

  ngOnDestroy(){
    this.modalDataSub?.unsubscribe();
  }

}
