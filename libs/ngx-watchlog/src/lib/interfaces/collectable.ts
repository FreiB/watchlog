import { LogEvent } from './log-event';

export interface Collectable {
  timestamp: number;
  route: string;
  message: any;
  type: string;
}
