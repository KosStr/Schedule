export class EnumHelperService {
  static enumSelector(definition): Array<Object> {
    return Object.keys(definition).map(key => ({ value: definition[key], title: key })).slice(Object.keys(definition).length / 2);
  }
}
