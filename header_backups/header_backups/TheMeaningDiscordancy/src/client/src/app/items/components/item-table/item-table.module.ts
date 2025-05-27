import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemTileComponent } from './item-tile/item-tile.component';
import { ItemTableComponent } from './item-table.component';

@NgModule({
  declarations: [
    ItemTileComponent,
    ItemTableComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    ItemTableComponent
  ]
})
export class ItemTableModule { }
