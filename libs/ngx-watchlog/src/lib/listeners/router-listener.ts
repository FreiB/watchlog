import { Injectable } from '@angular/core';
import { NavigationEnd, NavigationStart, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { PerformanceMarks } from '../consts/marks';
import { LogEvent } from '../interfaces/log-event';
import { WatchlogListener } from '../interfaces/watchlog-listener';

@Injectable({
  providedIn: 'root',
})
export class RouterListener implements WatchlogListener {
  events: Subject<LogEvent> = new Subject<LogEvent>();
  private navStart = 0;
  private startRoute = '';
  private navEnd = 0;

  constructor(private router: Router) {
    this.listenToRouterEvents();
  }

  private listenToRouterEvents() {
    this.router.events.subscribe((e) => {
      if (e instanceof NavigationStart) {
        this.navStart = performance.now();
        this.startRoute = this.router.url;
      }
      if (e instanceof NavigationEnd) {
        this.navEnd = performance.now();
        const log = {
          type: PerformanceMarks.Routing,
          duration: this.navEnd - this.navStart,
          startRoute: this.startRoute,
          endRoute: e.url,
        };
        this.events.next(log);
      }
    });
  }
}
