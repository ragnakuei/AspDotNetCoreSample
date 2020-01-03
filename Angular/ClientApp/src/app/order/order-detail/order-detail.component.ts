import { Component, OnInit } from "@angular/core";
import { Location } from "@angular/common";
import { FormBuilder, FormGroup, Validators, FormArray } from "@angular/forms";
import { OrderService } from "../order.service";
import { ActivatedRoute, Router, Params } from "@angular/router";
import { Order } from "src/app/models/Order";
import { MatDialog } from "@angular/material/dialog";
import { OrderConfirmDeleteDialogComponent } from "../order-confirm-delete-dialog/order-confirm-delete-dialog.component";
import { MatDatepicker } from "@angular/material/datepicker";
import { OrderDetail } from 'src/app/models/OrderDetail';

@Component({
  selector: "app-order-detail",
  templateUrl: "./order-detail.component.html",
  styleUrls: ["./order-detail.component.css"]
})
export class OrderDetailComponent implements OnInit {
  orderId: number;
  order: Order;
  orderForm: FormGroup;
  isReadOnly: boolean = true;

  constructor(
    private orderService: OrderService,
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    public dialog: MatDialog,
    private formBuilder: FormBuilder
  ) {
    if (this.router.getCurrentNavigation().extras.state != undefined) {
      this.isReadOnly = this.router.getCurrentNavigation().extras.state.isReadonly;
    }
    console.log("isReadOnly:" + this.isReadOnly);
  }

  ngOnInit() {
    console.log(this.isReadOnly);

    this.route.params.subscribe((params: Params) => {
      this.orderId = params["id"];
      this.orderService.getOrder(this.orderId).subscribe(
        responseOrder => {
          this.order = responseOrder;
          this.orderForm = this.formBuilder.group({
            orderID: [responseOrder.orderID],
            customerID: [responseOrder.customerID, Validators.required],
            employeeID: [responseOrder.employeeID],
            orderDate: [responseOrder.orderDate],
            requiredDate: [responseOrder.requiredDate],
            shippedDate: [responseOrder.shippedDate],
            shipVia: [responseOrder.shipVia],
            freight: [responseOrder.freight],
            shipName: [responseOrder.shipName],
            shipAddress: [responseOrder.shipAddress],
            shipCity: [responseOrder.shipCity],
            shipRegion: [responseOrder.shipRegion],
            shipPostalCode: [responseOrder.shipPostalCode],
            shipCountry: [responseOrder.shipCountry],
            details: this.formBuilder.array(
              responseOrder.details.map(detail =>
                this.formBuilder.group({
                  productID: [detail.productID],
                  unitPrice: [detail.unitPrice],
                  quantity: [detail.quantity],
                  discount: [detail.discount]
                })
              )
            )
          });
        },
        err => console.log("Error", err)
      );
    });
  }

  addDetails() {
    (this.orderForm.get("details") as FormArray).push(
      this.formBuilder.group({
        productID: [""],
        unitPrice: [""],
        quantity: [""],
        discount: [""]
      })
    );
  }

  removeDetail(detailIndex: number) {
    (this.orderForm.get("details") as FormArray).removeAt(detailIndex);
  }

  changeToReadOnlyMode() {
    this.orderForm.reset(this.order);

    const detailFormArray = (this.orderForm.get("details") as FormArray);
    detailFormArray.clear();

    for(var detail of this.order.details)
    {
        detailFormArray.push(this.formBuilder.group({
            productID: [detail.productID],
            unitPrice: [detail.unitPrice],
            quantity: [detail.quantity],
            discount: [detail.discount]
          }));
    }

    this.isReadOnly = true;
  }

  changeToEditMode() {
    this.isReadOnly = false;
  }

  checkHidden() {
    let hiddenStyle = {
      visibility: this.isReadOnly ? "hidden" : ""
    };
    return hiddenStyle;
  }

  openDatePicker(datePicker: MatDatepicker<any>) {
    if (this.isReadOnly) {
      return;
    }

    datePicker.open();
  }

  deleteOrder() {
    const dialogRef = this.dialog.open(OrderConfirmDeleteDialogComponent, {
      width: "250px",
      data: this.orderId
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log("The dialog was closed");

      if (result === true) {
        this.router.navigate(["/order"]);
      }
    });
  }

  onSubmit(submitData: Order) {
    this.orderService.updateOrder(submitData).subscribe(
      val => {
        this.isReadOnly = true;
        this.ngOnInit();
      },
      response => {
        console.log("PUT call in error", response);
      }
    );
  }

  backToPreviousPage() {
    this.router.navigate(["/order"]);
  }
}
