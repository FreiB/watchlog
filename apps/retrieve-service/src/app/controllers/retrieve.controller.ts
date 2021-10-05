import { Controller, Get } from '@nestjs/common';
import { InfluxDB } from '@influxdata/influxdb-client';

@Controller('retrieve')
export class RetrieveController {
  @Get()
  retrieve() {
    const token =
      'dmjKzWOgYz4Dsw88Tu4hrfZyrhLnuvlGfkeim055QcBp7_3y_2Th0POm9gWAim1M7ag50PIueKFv1ePlQGrkqQ==';
    const org = 'F7';
    const bucket = 'watchlog-dev';
    const client = new InfluxDB({ url: 'http://localhost:8086', token: token });

    const queryApi = client.getQueryApi(org);

    const query = `from(bucket: "${bucket}") |> range(start: -4h) |> filter(fn: (r) => r._measurement == "perf-navigation")`;
    queryApi.queryRows(query, {
      next(row, tableMeta) {
        const o = tableMeta.toObject(row);
        console.log(
          `${o._time} ${o._measurement} in '${o.session_id}' (${o.client_ip}): ${o._field}=${o._value}`
        );
      },
      error(error) {
        console.error(error);
        console.log('\\nFinished ERROR');
      },
      complete() {
        console.log('\\nFinished SUCCESS');
      },
    });

    return 0;
  }
}
