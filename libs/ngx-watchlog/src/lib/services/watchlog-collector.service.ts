import { HttpBackend, HttpClient } from '@angular/common/http';
import {
  ApplicationRef,
  assertPlatform,
  Inject,
  Injectable,
  NgZone,
  Optional,
} from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { merge } from 'rxjs';
import {
  WATCHLOG_API,
  WATCHLOG_OPTIONS,
  WATCHLOG_LISTENER,
} from '../consts/tokens';
import { WatchlogListener } from '../interfaces/watchlog-listener';
import { WatchLogOptions } from '../interfaces/watchlog-options';
import { Collectable } from 'watchlog-shared';
import { Collector } from '../interfaces/collector';

declare global {
  interface Window {
    watchlog_collector: Collector;
  }
}
@Injectable({
  providedIn: 'root',
})
export class WatchlogCollectorService {
  private currentRoute = '';

  private get collection(): Collectable[] {
    if (!window.watchlog_collector) {
      window.watchlog_collector = {
        collection: [],
      };
    }
    return window.watchlog_collector.collection;
  }

  constructor(
    @Inject(WATCHLOG_API) private watchlogApi: string,
    @Inject(WATCHLOG_OPTIONS)
    private watchlogOptions: WatchLogOptions,
    @Inject(WATCHLOG_LISTENER)
    private listeners: WatchlogListener[],
    private router: Router
  ) {
    const subjects = listeners.map((l) => l.events);
    const merged = merge(...subjects);
    merged.subscribe((e) => {
      this.collect(e.type, e);
    });
    this.listenToRouterEvents();
  }

  public collect(type: string, message: any): void {
    this.collection.push({
      timestamp: Date.now(),
      route: this.currentRoute,
      message: message,
      type: type,
    });
  }

  private listenToRouterEvents() {
    this.router.events.subscribe((e) => {
      if (e instanceof NavigationEnd) {
        this.currentRoute = e.url;
      }
    });
  }
}
