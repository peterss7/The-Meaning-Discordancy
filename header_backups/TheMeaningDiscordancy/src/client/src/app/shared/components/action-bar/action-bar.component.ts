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

import { Component, Input } from '@angular/core';
import { StylesService } from '../../services/styles.service';

@Component({
  selector: 'discord-action-bar',
  templateUrl: './action-bar.component.html',
  styleUrls: ['./action-bar.component.scss']
})
export class ActionBarComponent {
  @Input() name = '';

  public backgroundImage: string = 'panel-left';

  constructor(public stylesService: StylesService) { }

  getImageStyle(): { [key: string]: string } {
    return this.stylesService.getImageStyle(this.backgroundImage);
  }
}
