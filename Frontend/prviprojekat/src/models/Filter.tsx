import ToolType from "./ToolType";

class ToolFilter {
  constructor(
    public powerSupply: ToolPowerSupplyCategory[] | null = null,
    public toolType: ToolType[] | null = null,
    public priceBetween: number[] | null = null,
    public dateCreatedAfter: Date | null = null,
    public brand: string[] | null = null
  ) {}
}

export default ToolFilter;
