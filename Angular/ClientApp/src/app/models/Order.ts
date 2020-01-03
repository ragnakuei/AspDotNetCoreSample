import { OrderDetail } from './OrderDetail';
export class Order {
    orderID: number;
    customerID: string;
    employeeID: number;
    orderDate: string;
    requiredDate: string;
    shippedDate: string;
    shipVia: number;
    freight: number;
    shipName: string;
    shipAddress: string;
    shipCity: string;
    shipRegion: null;
    shipPostalCode: string;
    shipCountry: string;
    details: OrderDetail[];
}
