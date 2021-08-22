import axios from "axios";
import { BaseApi } from "./index";
class EmployeeApi extends BaseApi {
    constructor(){
        super();
        this.entity = "employee";
        
    }
    async getEmployeeFilter(specs, pageSize, pageIndex){
        return await axios.get(`${this.url}/${this.entity}/filter?specs=${specs}&pagesize=${pageSize}&pageindex=${pageIndex}`)
        
    }
    async getNewEmployeeCode(){
        return await axios.get(`${this.url}/${this.entity}/newcode`)
    }
    
}

export default new EmployeeApi()