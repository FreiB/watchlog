import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { NgxWatchlogModule } from 'ngx-watchlog';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot(
      [
        {
          path: 'home',
          loadChildren: () =>
            import('./modules/home/home.module').then((m) => m.HomeModule),
        },
      ],
      { initialNavigation: 'enabledBlocking' }
    ),
    NgxWatchlogModule.forRoot('/api'),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
