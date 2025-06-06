﻿// Copyright © 2025 Steven Peterson
// All rights reserved.  
// 
// No part of this code may be copied, modified, distributed, or used  
// without explicit written permission from the author.
// 
// For licensing inquiries or collaboration opportunities:
// 
// GitHub: https://github.com/peterss7  
// LinkedIn: https://www.linkedin.com/in/steven-peterson7405926/

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalService } from './services/modal.service';
import { LayoutModule } from './layout/layout.module';
import { NormalizeUrlPipe } from './pipes/normalize-url.pipe';
import { ComponentsModule } from './components/components.module';
import { StylesService } from './services/styles.service';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    LayoutModule,
    ComponentsModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatDialogModule,
  ],
  providers: [
    ModalService,
    NormalizeUrlPipe,
    StylesService,
  ],
  exports: [
  ]
})
export class SharedModule { }
