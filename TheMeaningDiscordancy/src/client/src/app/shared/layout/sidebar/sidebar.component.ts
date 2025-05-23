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
