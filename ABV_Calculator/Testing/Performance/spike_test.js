import http from 'k6/http';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '5s', target: 50 },
        { duration: '5s', target: 50 },
        { duration: '20s', target: 1000 },
        { duration: '10s', target: 50 },
        { duration: '5s', target: 50 },
        { duration: '20s', target: 1500 },
        { duration: '10s', target: 50 },
        { duration: '5s', target: 50 },
        { duration: '5s', target: 0 },
    ],
    thresholds: {
        http_req_duration: ['p(95)<150'], // 99% of requests must complete in less than 150ms
    },
};

export default function ()  {
};

