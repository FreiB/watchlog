import { ApplicationRef, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, Subscription } from 'rxjs';
import { PerformanceMarks } from '../consts/marks';
import { LogEvent } from '../interfaces/log-event';
import { WatchlogListener } from '../interfaces/watchlog-listener';

@Injectable({
  providedIn: 'root',
})
export class BootListener implements WatchlogListener {
  events: Subject<LogEvent> = new Subject<LogEvent>();
  stableSub!: Subscription;

  initTime = 0;

  constructor(private appRef: ApplicationRef) {
    this.listenToBootEvents();
  }

  private listenToBootEvents(): void {
    this.stableSub = this.appRef.isStable.subscribe((s) => {
      if (s) {
        performance.measure(PerformanceMarks.AppStable);
        // const bootTime =
        //   performance.now() - (window as any).WATCHLOG_BOOT_START;
        // const log = {
        //   type: 'Boot',
        //   duration: bootTime,
        // };
        // this.events.next(log);
        this.stableSub.unsubscribe();
      }
    });
  }
}
