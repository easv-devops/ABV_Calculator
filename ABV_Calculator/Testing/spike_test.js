import http from 'k6/http';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '30s', target: 50 },
        { duration: '30s', target: 50 },
        { duration: '20s', target: 800 },
        { duration: '10s', target: 800 },
        { duration: '20s', target: 50 },
        { duration: '30s', target: 50 },
        { duration: '20s', target: 1200 },
        { duration: '10s', target: 1200 },
        { duration: '20s', target: 50 },
        { duration: '10s', target: 0 },
    ],
    thresholds: {
        http_req_duration: ['p(95)<150'], // 99% of requests must complete in less than 150ms
    },
};

export default function ()  {
};

