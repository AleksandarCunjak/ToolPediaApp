class Tool {
  id!: string; // Assuming Guid is represented as a string
  name!: string;
  description?: string | null; // Optional property
  powerSupply!: string; // Assuming ToolPowerSupplyCategory is represented as a string
  toolType!: string; // Assuming ToolType is represented as a string
  characteristics!: object; // Assuming Characteristics is represented as a JSON object
  images!: string;
  brand!: string;
  price!: number;
  visits!: number; // Default value will be handled separately
  dateCreated!: Date; // Assuming DateTime is represented as a string
}

export default Tool;
