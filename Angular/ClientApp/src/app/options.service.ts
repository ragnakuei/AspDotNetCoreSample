import { Inject, Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { CustomerOption } from './models/CustomerOption';
import { map } from 'rxjs/internal/operators/map';
import { tap } from 'rxjs/internal/operators/tap';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class OptionsService {
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };

    constructor(@Inject('BASE_API_URL')
                private  baseUrl: string,
                private httpClient: HttpClient) {
    }

    getCustomers(keyword: string): Observable<CustomerOption[]> {
        return this.httpClient
                   .get<CustomerOption[]>(this.baseUrl + 'options/customers', {
                       params: {
                           keyword: keyword
                       },
                       observe: 'response'
                   })
                   .pipe(
                       map(resp => resp.body),
                       tap(_ => this.log('get Cusomers'))
                   );
    }

    private log(message: string) {
        console.log(message);
    }
}
