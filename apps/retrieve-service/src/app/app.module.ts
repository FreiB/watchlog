import { Module } from '@nestjs/common';

import { AppController } from './app.controller';
import { AppService } from './app.service';
import { RetrieveController } from './controllers/retrieve.controller';

@Module({
  imports: [],
  controllers: [AppController, RetrieveController],
  providers: [AppService],
})
export class AppModule {}
