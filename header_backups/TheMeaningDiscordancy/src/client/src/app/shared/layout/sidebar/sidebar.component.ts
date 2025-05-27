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

import { Component } from '@angular/core';
import { ConfigService } from 'src/app/core/services/config.service';
import { StylesService } from '../../services/styles.service';

@Component({
  selector: 'discord-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {

  constructor(public configService: ConfigService,
    private stylesService: StylesService
  ){}

  getAssetsFolder(name: string): { [key: string]: string } {
    var result = this.stylesService.getImageStyle(name);
    console.log(`Sidebar found this img: ${JSON.stringify(result)}`);
    return result;
  }
}
