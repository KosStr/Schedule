export class SharedAutocompleteConfiguration {
  fontSize: number;
  padding: string;
  multiple: boolean;
  displayMultiple: boolean;
  selectIcon: string;
  autocompletePlaceholder: string;
  panelWidth: number;
  selectedBackground: string;
  itemComparer: Function;
  displayedProperties: Array<string>;
  color: string;
  opacity: string;

  constructor(cfg: Partial<SharedAutocompleteConfiguration>) {
    this.fontSize = cfg.fontSize;
    this.padding = cfg.padding;
    this.multiple = cfg.multiple;
    this.displayMultiple = cfg.displayMultiple;
    this.selectIcon = cfg.selectIcon;
    this.autocompletePlaceholder = cfg.autocompletePlaceholder;
    this.panelWidth = cfg.panelWidth;
    this.selectedBackground = cfg.selectedBackground;
    cfg.itemComparer
      ? (this.itemComparer = cfg.itemComparer)
      : (this.itemComparer = (x, y) => x === y);
    this.displayedProperties = cfg.displayedProperties;
    this.color = cfg.color;
    this.opacity = cfg.opacity;
  }
}
