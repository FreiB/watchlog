import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { WatchlogCollectorService } from '../services/watchlog-collector.service';

@Injectable()
export class WatchlogInterceptor implements HttpInterceptor {
  constructor(private collector: WatchlogCollectorService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    const startTime = performance.now();
    return next.handle(request).pipe(
      tap((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          const endTime = performance.now();
          const message = {
            duration: endTime - startTime,
            url: request.url,
            method: request.method,
            status: event.status,
          };
          this.collector.collect('Http', message);
        }
      })
    );
  }
}
