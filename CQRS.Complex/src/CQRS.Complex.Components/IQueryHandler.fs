namespace CQRS.Complex.Components

type IQueryHandler<'aQuery, 'bResult when 'aQuery :> IQuery<'bResult>> =
    abstract member Handle : query : 'aQuery -> Result<'bResult, string>