import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IconButtonComponent } from './icon-button/icon-button.component';
import { ActionBarComponent } from './action-bar/action-bar.component';
import { ModalComponent } from './modal/modal.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { FileUploadComponent } from './file-upload/file-upload.component';

@NgModule({
  declarations: [
    IconButtonComponent,
    ActionBarComponent,
    ModalComponent,
    FileUploadComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
    MatButtonModule,
    MatDialogModule,
    MatIconModule
  ],
  exports:[
    IconButtonComponent,
    ActionBarComponent,   
  ],
  providers: [
  ]
})
export class ComponentsModule { }
