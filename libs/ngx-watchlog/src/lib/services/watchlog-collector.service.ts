import { HttpBackend, HttpClient } from '@angular/common/http';
import {
  ApplicationRef,
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

@Injectable({
  providedIn: 'root',
})
export class WatchlogCollectorService {
  private http: HttpClient;
  //private collection: Collectable[] = [];
  private currentRoute = '';
  private collectIntervalMs: number;

  private get collection(): Collectable[] {
    return (window as any).watchlog_collector.collection;
  }

  constructor(
    private ngZone: NgZone,
    private httpBackend: HttpBackend,
    @Inject(WATCHLOG_API) private watchlogApi: string,
    @Inject(WATCHLOG_OPTIONS)
    private watchlogOptions: WatchLogOptions,
    @Inject(WATCHLOG_LISTENER)
    private listeners: WatchlogListener[],
    private router: Router
  ) {
    this.collectIntervalMs = watchlogOptions.collectIntervalSeconds * 1000;
    const subjects = listeners.map((l) => l.events);
    const merged = merge(...subjects);
    merged.subscribe((e) => {
      this.collect(e.type, e);
    });
    this.listenToRouterEvents();
    this.http = new HttpClient(httpBackend);
  }

  public startReporting() {
    // this.ngZone.runOutsideAngular(() => {
    //   this.http.get(`${this.watchlogApi}/session`).subscribe(() => {
    //     this.postCollectionRepeating();
    //   });
    // });
  }

  public collect(type: string, message: any): void {
    this.collection.push({
      timestamp: Date.now(),
      route: this.currentRoute,
      message: message,
      type: type,
    });
  }

  private postCollectionRepeating() {
    setTimeout(() => {
      this.postCollection();
      this.postCollectionRepeating();
    }, this.collectIntervalMs);
  }

  private postCollection() {
    if (this.collection.length > 0) {
      console.log(this.collection);
      const itemsToSend = [...this.collection];
      this.http
        .post(
          `${this.watchlogApi}/collect`,
          {
            collection: itemsToSend,
          },
          { withCredentials: true }
        )
        .subscribe(() => {
          console.log('collected');
        });
    }
  }

  private listenToRouterEvents() {
    this.router.events.subscribe((e) => {
      if (e instanceof NavigationEnd) {
        this.currentRoute = e.url;
      }
    });
  }
}
