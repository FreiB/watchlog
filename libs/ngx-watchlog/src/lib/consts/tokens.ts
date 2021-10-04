import { InjectionToken } from '@angular/core';
import { WatchlogListener } from '../interfaces/watchlog-listener';
import { WatchLogOptions } from '../interfaces/watchlog-options';

export const WATCHLOG_API: InjectionToken<string> = new InjectionToken<string>(
  'WatchlogApi'
);
export const WATCHLOG_OPTIONS: InjectionToken<WatchLogOptions> =
  new InjectionToken<WatchLogOptions>('WatchlogOptions');

export const WATCHLOG_LISTENER: InjectionToken<WatchlogListener> =
  new InjectionToken<WatchlogListener>('WatchlogListener');
