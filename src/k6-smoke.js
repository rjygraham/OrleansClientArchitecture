import http from 'k6/http';
import { check, group, sleep, fail } from 'k6';
import uuid from './uuid.js';

export const options = {
  vus: 10, // 1 user looping for 1 minute
  duration: '1m',

  thresholds: {
    http_req_duration: ['p(99)<1500'], // 99% of requests must complete below 1.5s
  },
};

export default () => {

    //const id = uuid.v1();
    //const id = 'a7af00a0-5e53-4d8c-8274-94adc77463ce';
    
    const url = 'http://localhost:5000/profile';

    const payload = JSON.stringify({
        givenName: 'Jane',
        surname: 'Doe',
        dateOfBirth: '1980-12-05T00:00:00.00+00:00',
        emailAddress: 'jane@example.com',
        phoneNumber: '5555551234'
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const res = http.post(url, payload, params);

    check(res, {
        'is status 200': (r) => r.status == 200
    });

};
