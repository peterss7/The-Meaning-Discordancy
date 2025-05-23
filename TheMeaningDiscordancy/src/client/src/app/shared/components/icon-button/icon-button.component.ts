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
