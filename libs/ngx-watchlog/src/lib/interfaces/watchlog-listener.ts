import { Subject } from 'rxjs';
import { LogEvent } from './log-event';

export interface WatchlogListener {
  events: Subject<LogEvent>;
}
