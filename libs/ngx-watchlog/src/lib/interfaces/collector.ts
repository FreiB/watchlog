import { Collectable } from 'watchlog-shared';

export interface Collector {
  serviceUrl?: string;
  collectInterval?: number;
  collectDelay?: number;
  collectLimit?: number;
  collection: Collectable[];
}
