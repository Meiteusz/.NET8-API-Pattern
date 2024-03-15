﻿
namespace AutoglassChallenge.API.ResponseBuilder
{
    public class ResponseModelBuilder
    {
        private object? _data = null;
        private string _message = string.Empty;
        private bool _success = false;
        private string _alertType = string.Empty;

        public ResponseModelBuilder WithData(object? data)
        {
            _data = data;
            return this;
        }

        public ResponseModelBuilder WithMessage(string message)
        {
            _message = message;
            return this;
        }

        public ResponseModelBuilder WithSuccess()
        {
            _success = true;
            return this;
        }

        public ResponseModel Build()
        {
            return new ResponseModel
            {
                Data = _data,
                Message = _message,
                Success = _success,
            };
        }
    }
}
