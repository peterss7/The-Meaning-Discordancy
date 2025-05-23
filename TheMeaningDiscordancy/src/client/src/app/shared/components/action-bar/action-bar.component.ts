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
