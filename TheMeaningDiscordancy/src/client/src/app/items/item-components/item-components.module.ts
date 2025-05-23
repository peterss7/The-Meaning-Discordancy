import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemTableComponent } from './item-table/item-table.component';
import { ItemActionBarComponent } from './item-action-bar/item-action-bar.component';
import { ComponentsModule } from 'src/app/shared/components/components.module';
import { ItemModalComponent } from './item-modal/item-modal.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    ItemTableComponent,
    ItemActionBarComponent,
    ItemModalComponent
  ],
  imports: [
    CommonModule,    
    ComponentsModule,
    SharedModule,
    FormsModule,   
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,    
  ],
  exports: [
    ItemModalComponent,
    ItemTableComponent,
    ItemActionBarComponent,
  ]

})
export class ItemComponentsModule { }
