<template>
    <div v-if="this.productDTOs.length > 0">
        <h3>Product List</h3>
        <table>
            <thead>
            <tr>
                <th>ProductID</th>
                <th>ProductName</th>
                <th>SupplierID</th>
                <th>CategoryID</th>
                <th>QuantityPerUnit</th>
                <th>UnitPrice</th>
                <th>UnitsInStock</th>
                <th>UnitsOnOrder</th>
                <th>ReorderLevel</th>
                <th>Discontinued</th>
            </tr>
            </thead>
            <tbody>
            <tr v-for="(productDTO, name, index) in this.productDTOs" :key="index">
                <td>{{ productDTO.productID }}</td>
                <td>{{ productDTO.productName }}</td>
                <td>{{ productDTO.supplierID }}</td>
                <td>{{ productDTO.categoryID }}</td>
                <td>{{ productDTO.quantityPerUnit }}</td>
                <td>{{ productDTO.unitPrice }}</td>
                <td>{{ productDTO.unitsInStock }}</td>
                <td>{{ productDTO.unitsOnOrder }}</td>
                <td>{{ productDTO.reorderLevel }}</td>
                <td>{{ productDTO.discontinued }}</td>
            </tr>
            </tbody>
        </table>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from "vue-property-decorator"
    import { IProductDTO } from "@/models/IProductDTO";
    import { ProductService } from "@/components/ProductService";

    @Component
    export default class Products extends Vue {
        private productDTOs: Array<IProductDTO>;
        private productService: ProductService;

        constructor() {
            super();
            this.productDTOs = new Array<IProductDTO>();
            this.productService = new ProductService();
        }

        async mounted() {
            try {
                this.productDTOs = (await this.productService.GetProductList()).data;
            } catch (err) {
                console.log(err);
                console.log(err.response);
            }
        }
    }
</script>

<style scoped>
    table {
        margin: 0 auto; /* or margin: 0 auto 0 auto */
    }
</style>
