import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app';
import { provideRouter } from '@angular/router';
import { AppRoutingModule } from './app/app-routing-module';
bootstrapApplication(App, {
  providers: [

  ]
}).catch(err => console.error(err));
