namespace Application.Extensions;

public static class DefaultValueExtensions {
  public static string OrDefaultValue(this string stringValue, string defaultValue) {
    return !string.IsNullOrWhiteSpace(stringValue)
      ? stringValue.Trim()
      : defaultValue;
  }

  public static int OrDefaultValue(this int intValue, int defaultValue) {
    return intValue != 0
      ? intValue
      : defaultValue;
  }
}