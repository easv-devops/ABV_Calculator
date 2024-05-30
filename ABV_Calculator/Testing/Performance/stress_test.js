import http from 'k6/http';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '5s', target: 100 },
        { duration: '10s', target: 100 },
        { duration: '5s', target: 500 },
        { duration: '10s', target: 500 },
        { duration: '5s', target: 1000 },
        { duration: '10s', target: 1000 },
        { duration: '5s', target: 2000 },
        { duration: '10s', target: 2000 },
        { duration: '5s', target: 3000 },
        { duration: '10s', target: 3000 },
    ],
    thresholds: {
        http_req_duration: ['p(95)<150'], // 99% of requests must complete in less than 150ms
    },
};

export default function ()  {
    let response = http.get("http://5.189.148.90:8081/ABV_Calculator/");
};