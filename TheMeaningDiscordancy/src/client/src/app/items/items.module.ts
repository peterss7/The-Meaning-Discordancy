import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemsService } from './services/items.service';
import { SharedModule } from '../shared/shared.module';
import { ItemsComponent } from './items.component';
import { ItemComponentsModule } from './item-components/item-components.module';

@NgModule({
  declarations: [
    ItemsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ItemComponentsModule
  ],
  providers:[
    ItemsService,
  ],
  exports:[
  ]
})
export class ItemsModule { }
