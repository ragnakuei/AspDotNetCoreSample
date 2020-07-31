import { Component, Vue } from 'vue-property-decorator';
import { AxiosResponse } from "axios";
import { IProductDTO } from "@/models/IProductDTO";

@Component
export class ProductService extends Vue {

    public async GetProductList(): Promise<AxiosResponse<Array<IProductDTO>>> {
        return await this.$axios.post<Array<IProductDTO>>("api/product/list");
    }

}
