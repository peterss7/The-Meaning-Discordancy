import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IconButtonComponent } from './icon-button/icon-button.component';
import { ActionBarComponent } from './action-bar/action-bar.component';
import { ModalComponent } from './modal/modal.component';
import { MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    IconButtonComponent,
    ActionBarComponent,
    ModalComponent,
  ],
  imports: [
    CommonModule  
  ],
  exports:[
    IconButtonComponent,
    ActionBarComponent,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
  providers: [
    MatDialogRef
  ]
})
export class ComponentsModule { }
