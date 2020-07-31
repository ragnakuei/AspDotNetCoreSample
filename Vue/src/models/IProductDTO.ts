export interface IProductDTO {
    productID: number;
    productName: string;
    supplierID: number | null;
    categoryID: number | null;
    quantityPerUnit: string;
    unitPrice: number | null;
    unitsInStock: number | null;
    unitsOnOrder: number | null;
    reorderLevel: number | null;
    discontinued: boolean;
}
