import { Component, EventEmitter, Output } from '@angular/core';
import { StylesService } from 'src/app/shared/services/styles.service';
import { ItemsService } from '../../services/items.service';
import { ModalService } from 'src/app/shared/services/modal.service';
import { ModalData } from 'src/app/shared/models/modal-data.model';

@Component({
  selector: 'discord-item-action-bar',
  templateUrl: './item-action-bar.component.html',
  styleUrls: ['./item-action-bar.component.scss']
})
export class ItemActionBarComponent {

  constructor(private stylesService: StylesService,
    private itemsService: ItemsService,
    private modalService: ModalService
  ) { }

  getImageStyle(name: string): { [key: string]: string } {
    var result = this.stylesService.getImageStyle(name);
    console.log(`assets folder found in item action bar comp: ${JSON.stringify(result)}`);
    return result;
  }

  uploadClick(): void {
    this.modalService.setModalData('upload');
  }
  updateClick(): void {
    this.modalService.setModalData('update');
  }
  deleteClick(): void {
    this.modalService.setModalData('delete');
  }
  refreshClick(): void {
    this.itemsService.refresh();
  }
}
