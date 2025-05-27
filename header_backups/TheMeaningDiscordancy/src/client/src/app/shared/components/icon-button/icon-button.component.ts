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

import { Component, EventEmitter, Input, Output } from '@angular/core';
import { StylesService } from '../../services/styles.service';

@Component({
  selector: 'discord-icon-button',
  templateUrl: './icon-button.component.html',
  styleUrls: ['./icon-button.component.scss']
})
export class IconButtonComponent {
  @Input() name = '';
  @Input() tooltip = '';
  @Input() label = '';
  @Input() disabled = false;

  @Output() clicked = new EventEmitter<void>();

  constructor(public stylesService: StylesService) { }

  getImageStyle(): { [key: string]: string } {
    return this.stylesService.getImageStyle(this.name);
  }

  handleClick(): void {
    if (!this.disabled) {
      this.clicked.emit();
    }
  }
}
