import { isPlatformBrowser } from '@angular/common';
import {
  HttpBackend,
  HttpClientModule,
  HTTP_INTERCEPTORS,
} from '@angular/common/http';
import {
  APP_INITIALIZER,
  Inject,
  ModuleWithProviders,
  NgModule,
  PLATFORM_ID,
} from '@angular/core';
import { DEFAULT_WATCHLOG_OPTIONS } from './consts/default-options';
import { PerformanceMarks } from './consts/marks';
import {
  WATCHLOG_API,
  WATCHLOG_OPTIONS,
  WATCHLOG_LISTENER,
} from './consts/tokens';
import { WatchlogInterceptor } from './interceptors/watchlog.interceptor';
import { WatchLogOptions } from './interfaces/watchlog-options';
import { BootListener } from './listeners/boot-listener';
import { BrowserListener } from './listeners/browser-listener';
import { RouterListener } from './listeners/router-listener';

function initializeAppFactory(): () => void {
  return () => performance.mark(PerformanceMarks.AppInit);
}

function watchlogPlatformListenerFactory(platformId: never) {
  if (isPlatformBrowser(platformId)) {
    return new BrowserListener();
  }
  return null;
}

@NgModule({
  declarations: [],
  imports: [HttpClientModule],
  exports: [],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: WatchlogInterceptor,
      multi: true,
    },
    {
      provide: APP_INITIALIZER,
      multi: true,
      useFactory: initializeAppFactory,
    },
    {
      provide: WATCHLOG_LISTENER,
      deps: [PLATFORM_ID],
      multi: true,
      useFactory: watchlogPlatformListenerFactory,
    },
    {
      provide: WATCHLOG_LISTENER,
      multi: true,
      useClass: RouterListener,
    },
    {
      provide: WATCHLOG_LISTENER,
      multi: true,
      useClass: BootListener,
    },
  ],
})
export class NgxWatchlogModule {
  static forRoot(
    apiUrl: string,
    options?: WatchLogOptions
  ): ModuleWithProviders<NgxWatchlogModule> {
    return {
      ngModule: NgxWatchlogModule,
      providers: [
        {
          provide: WATCHLOG_API,
          useValue: apiUrl,
        },
        {
          provide: WATCHLOG_OPTIONS,
          useValue: Object.assign(DEFAULT_WATCHLOG_OPTIONS, options),
        },
      ],
    };
  }
}
