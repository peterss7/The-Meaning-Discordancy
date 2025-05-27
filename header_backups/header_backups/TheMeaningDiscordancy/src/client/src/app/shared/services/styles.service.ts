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
