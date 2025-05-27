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

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigService } from './services/config.service';
import { ClientService } from './services/client.service';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    
  ],
  providers:[
    ConfigService,
    ClientService,    
  ]
})
export class CoreModule { }
