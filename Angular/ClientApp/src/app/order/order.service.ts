import { Inject, Injectable } from "@angular/core";
import {
    HttpClient,
    HttpHeaders,
} from "@angular/common/http";
import { OrderList } from "../models/OrderList";
import { Order } from "../models/Order";
import { Observable } from "rxjs";
import { map, tap } from "rxjs/operators";

@Injectable()
export class OrderService {
        httpOptions = {
        headers: new HttpHeaders({
            "Content-Type": "application/json"
        })
    };

    constructor(@Inject('BASE_API_URL')
                private  baseUrl: string,
                private httpClient: HttpClient) {
    }

    public getList(pageIndex: number, pageSize: number): Observable<OrderList> {
        return this.httpClient
                   .get<OrderList>(this.baseUrl + "order/list", {
                       params: {
                           pageIndex: pageIndex.toString(),
                           pageSize: pageSize.toString()
                       },
                       observe: "response"
                   })
                   .pipe(
                       map(resp => resp.body),
                       tap(_ => this.log("get order list"))
                   );
    }

    public getOrder(orderId: number): Observable<Order> {
        return this.httpClient
                   .get<Order>(this.baseUrl + "order/detail/" + orderId, {
                       observe: "response"
                   })
                   .pipe(
                       map(resp => resp.body),
                       tap(_ => this.log("get order id:" + orderId))
                   );
    }

    createOrder(order: Order) {
        return this.httpClient
                   .post<number>(
                       this.baseUrl + "order/create",
                       order,
                       this.httpOptions
                   )
                   .pipe(tap(_ => this.log("create order")));
    }

    public updateOrder(order: Order) {
        return this.httpClient
                   .put<number>(
                       this.baseUrl + "order/" + order.orderID,
                       order,
                       this.httpOptions
                   )
                   .pipe(tap(_ => this.log("update order id:" + order.orderID)));
    }

    public deleteOrder(orderId: number) {
        return this.httpClient
                   .delete<number>(
                       this.baseUrl + "order/" + orderId,
                       this.httpOptions
                   )
                   .pipe(tap(_ => this.log("delete order id:" + orderId)));
    }

    private log(message: string) {
        console.log(message);
    }
}
