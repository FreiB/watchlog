import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { LogEvent } from '../interfaces/log-event';
import { WatchlogListener } from '../interfaces/watchlog-listener';

@Injectable({
  providedIn: 'root',
})
export class BrowserListener implements WatchlogListener {
  events: Subject<LogEvent> = new Subject<LogEvent>();

  constructor() {
    this.listenToBrowserEvents();
  }

  private listenToBrowserEvents(): void {
    // window.addEventListener('beforeunload', () => {
    //   this.events.next({
    //     type: 'Application Exit',
    //   });
    // });
    // document.addEventListener('visibilitychange', () => {
    //   if (document.visibilityState === 'visible') {
    //     this.events.next({
    //       type: 'Application Visible',
    //     });
    //   } else {
    //     this.events.next({
    //       type: 'Application Hidden',
    //     });
    //   }
    // });
  }
}
