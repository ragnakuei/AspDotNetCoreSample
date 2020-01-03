import { Location } from "@angular/common";
import { Component, OnInit, ViewEncapsulation } from "@angular/core";
import { FormArray, FormControl, FormGroup } from "@angular/forms";
import {
  MatAutocompleteModule,
  MatAutocompleteSelectedEvent
} from "@angular/material/autocomplete";
import { ActivatedRoute, Router } from "@angular/router";
import { debounceTime, tap } from "rxjs/operators";
import { CustomerOption } from "src/app/models/CustomerOption";
import { Order } from "src/app/models/Order";
import { OptionsService } from "src/app/options.service";
import { OrderService } from "../order.service";

@Component({
  encapsulation: ViewEncapsulation.None,
  selector: "app-order-create",
  styleUrls: ["./order-create.component.css"],
  templateUrl: "./order-create.component.html"
})
export class OrderCreateComponent implements OnInit {
  public orderForm: FormGroup;
  public customerOptions: CustomerOption[] = [];

  constructor(
    private orderService: OrderService,
    private optionsService: OptionsService,
    private location: Location,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  public ngOnInit() {
    this.orderForm = new FormGroup({
      customerID: new FormControl(""),
      details: new FormArray([]),
      employeeID: new FormControl(""),
      freight: new FormControl(""),
      orderDate: new FormControl(""),
      requiredDate: new FormControl(""),
      shipAddress: new FormControl(""),
      shipCity: new FormControl(""),
      shipCountry: new FormControl(""),
      shipName: new FormControl(""),
      shipPostalCode: new FormControl(""),
      shipRegion: new FormControl(""),
      shipVia: new FormControl(""),
      shippedDate: new FormControl("")
    });

    this.orderForm
      .get("customerID")
      .valueChanges.pipe(
        debounceTime(300),
        tap(val => {
          console.log("keyword:" + val);
        })
      )
      .subscribe(inputKeyword => {
        if (typeof inputKeyword === "string") {
          this.optionsService.getCustomers(inputKeyword).subscribe(
            queryOptions => {
              this.customerOptions = queryOptions;
            },
            err => console.log("Error", err)
          );
        }
      });
  }

  public highlightFiltered(customerName: string) {

    console.log('highlightFiltered');

    const inputCustomerKeyword = this.orderForm.get("customerID").value;
    if (typeof inputCustomerKeyword === "string") {
      const pattern = inputCustomerKeyword
        .replace(/[\-\[\]\/\{\}\(\)\*\+\?\.\\\^\$\|]/g, "\\$&")
        .split(" ")
        .filter(t => t.length > 0)
        .join("|");
      const regex = new RegExp(pattern, "gi");

      return inputCustomerKeyword
        ? customerName.replace(regex, match => `<span class="autocomplete-highlight">${match}</span>`)
        : customerName;
    }
    return customerName;
  }

  public addDetails() {
    (this.orderForm.get("details") as FormArray).push(
      new FormGroup({
        productID: new FormControl(""),
        unitPrice: new FormControl(""),
        quantity: new FormControl(""),
        discount: new FormControl("")
      })
    );
  }

  public removeDetail(detailIndex: number) {
    (this.orderForm.get("details") as FormArray).removeAt(detailIndex);
  }

  public onSubmit(submitData: Order) {
    if (typeof submitData.customerID === "object") {
      submitData.customerID = (submitData.customerID as CustomerOption).customerID;
    }
    this.orderService.createOrder(submitData).subscribe(
      val => {
        this.router.navigate(["/order/detail/" + val]);
      },
      err => console.log("Error", err)
    );
  }

  public backToPreviousPage() {
    this.location.back();
  }

  public displayCustomer(customOption: CustomerOption): string {
    if (customOption) {
      return `${customOption.customerID} / ${customOption.companyName}`;
    } else {
      return "";
    }
  }

  public onCustomerOptionChanged(e: MatAutocompleteSelectedEvent) { }
}
