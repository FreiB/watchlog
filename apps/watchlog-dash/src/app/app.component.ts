import { Component } from '@angular/core';
import { WatchlogCollectorService } from 'ngx-watchlog';

@Component({
  selector: 'watchlog-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  constructor(private collector: WatchlogCollectorService) {}
  title = 'watchlog-dash';
}
