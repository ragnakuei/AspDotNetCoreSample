import { Component, OnInit, ViewChild } from "@angular/core";
import { ActivatedRoute, Router, NavigationExtras } from "@angular/router";
import { OrderList } from "src/app/models/OrderList";
import { OrderListItem } from "src/app/models/OrderListItem";
import { OrderService } from "../order.service";
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatDialog } from "@angular/material/dialog";
import { OrderConfirmDeleteDialogComponent } from "../order-confirm-delete-dialog/order-confirm-delete-dialog.component";

@Component({
  templateUrl: "./order.list.component.html",
  styles: [
    `
      table {
        width: 100%;
      }
    `
  ]
})
export class OrderListComponent implements OnInit {
  displayedColumns: string[] = [
    "orderID",
    "customerID",
    "employeeID",
    "orderDate",
    "requiredDate",
    "shippedDate",
    "shipVia",
    "freight",
    "shipName",
    "shipAddress",
    "shipCity",
    "shipRegion",
    "shipPostalCode",
    "shipCountry",
    "management"
  ];

  orderListDataSource = new MatTableDataSource<OrderListItem>();

  @ViewChild("paginatorTop", { static: true })
  private paginatorTop: MatPaginator;

  @ViewChild("paginatorBottom", { static: true })
  private paginatorBottom: MatPaginator;

  totalCount: number;

  list: OrderList[] = [];

  constructor(
    private orderService: OrderService,
    private router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getOrderList(0, 10);

    this.paginatorTop.page.subscribe((page: PageEvent) => {
      this.getOrderList(page.pageIndex, page.pageSize);
    });

    this.paginatorBottom.page.subscribe((page: PageEvent) => {
      this.getOrderList(page.pageIndex, page.pageSize);
    });
  }

  private getOrderList(pageIndex: number, pageSize: number) {
    this.orderService.getList(pageIndex, pageSize).subscribe(
      resp => {
        this.orderListDataSource.data = resp.items;
        this.totalCount = resp.totalCount;

        this.paginatorTop.pageIndex = pageIndex;
        this.paginatorTop.pageSize = pageSize;
        this.paginatorBottom.pageIndex = pageIndex;
        this.paginatorBottom.pageSize = pageSize;
      },
      err => console.log("Error", err)
    );
  }

  goToDetailPage(orderId: number, isReadonly: boolean) {
    const navigationExtras: NavigationExtras = {
      state: { isReadonly: isReadonly }
    };
    this.router.navigate(["/order/detail", orderId], navigationExtras);
  }

  onSelect(orderId: number) {
    console.log(orderId);
  }

  openDeleteDialog(orderId: number): void {
    const dialogRef = this.dialog.open(OrderConfirmDeleteDialogComponent, {
      width: "250px",
      data: orderId
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log("The dialog was closed");

      if (result === true) {
        this.getOrderList(
          this.paginatorTop.pageIndex,
          this.paginatorTop.pageSize
        );
      }
    });
  }
}
