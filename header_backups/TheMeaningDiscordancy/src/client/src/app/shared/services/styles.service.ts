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

import { Injectable } from '@angular/core';
import { ConfigService } from 'src/app/core/services/config.service';

@Injectable({
  providedIn: 'root'
})
export class StylesService {

    constructor(private configService: ConfigService) { }
  
    getImageStyle(name: string): { [key: string]: string } {
      const assetsFolder = this.configService.config.assetsFolder;
      const imgUrl: string = `${assetsFolder}${name}.png`;
      return {
        backgroundImage: `url('${imgUrl}')`,
      };
    }
}
