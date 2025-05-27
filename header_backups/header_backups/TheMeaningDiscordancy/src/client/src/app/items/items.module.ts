import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemsService } from './services/items.service';
import { SharedModule } from '../shared/shared.module';
import { ItemsComponent } from './items.component';
import { ComponentsModule } from './components/components.module';
import { ItemTableModule } from "./components/item-table/item-table.module";

@NgModule({
  declarations: [
    ItemsComponent,    
  ],
  imports: [
    CommonModule,
    SharedModule,
    ComponentsModule,
    ItemTableModule
],
  providers:[
    ItemsService,
  ],
  exports:[
  ]
})
export class ItemsModule { }
