import { APP_INITIALIZER, NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ItemsModule } from './items/items.module';
import { LayoutModule } from './shared/layout/layout.module';
import { ComponentsModule } from './shared/components/components.module';
import { CoreModule } from './core/core.module';
import { ConfigService } from './core/services/config.service';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from './shared/shared.module';

export function initAppConfig(configService: ConfigService) {
  console.log(`Loading config...`);
  return () => configService.loadConfig(); // <- returns a Promise
}

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ItemsModule,
    LayoutModule,
    ComponentsModule,
    CoreModule,
    SharedModule,
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initAppConfig,
      deps: [ConfigService],
      multi: true
    }
  ],
  bootstrap: [AppComponent],  
})
export class AppModule { }
