# .NET Logging example

This application shows example usage of log4net and Serilog logging frameworks with Splunk logs aggregation software.

This example uses ASP.NET MVC application. Logging cofiguration may differ for .netcore.

Feel free to extend the example.

You need to have Splunk with Http Event Collector enabled.
- Default port for Http Event Collector is `8088`
- Default endpoint for Http Event Collector is `/services/collector`

## Log4Net configuration

- Splunk Event Collector token should be set in `web.config`
- Splunk host should be set in `web.config`

## Serilog configuration

- Splunk Event Collector endpoint and token should be specified in `HomeController` Serilog initialization

## Splunk Sources

To search for events from different loggers use the following Splunk sources:

- `http:test` - Serilog directly to Splunk
- `serilog` - Serilog to log4net which writes to Splunk
- `HomeController` - log4net directly to Splunk